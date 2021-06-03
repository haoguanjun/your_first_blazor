# Build your first blazor wasm app

## 创建项目

```bash
> dotnet new blazorwasm
The template "Blazor WebAssembly App" was created successfully.
This template contains technologies from parties other than Microsoft, see https://aka.ms/aspnetcore/6.0-third-party-notices for details.

Processing post-creation actions...
Running 'dotnet restore' on C:\mvp\2021\projects\your_first_blazor\your_first_blazor.csproj...
  Determining projects to restore...
  Restored C:\mvp\2021\projects\your_first_blazor\your_first_blazor.csproj (in 23.67 sec).
Restore succeeded.
```

## 项目内容

### Program.cs

```csharp
public static async Task Main(string[] args)
{
    // 
    var builder = WebAssemblyHostBuilder.CreateDefault(args);
    
    // 注册根组件
    builder.RootComponents.Add<App>("#app");

    // 注册 HttpClient 服务
    builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

    await builder.Build().RunAsync();
}
```

入口组件为 App, 映射到 wwwroot/index.html 页面中的 \#app 元素。 
```html
<div id="app">Loading...</div>
```
[WebAssemblyHostBuilder 源码](
https://github.com/dotnet/aspnetcore/blob/main/src/Components/WebAssembly/WebAssembly/src/Hosting/WebAssemblyHostBuilder.cs)


### 入口组件

App.razor 声明了布局组件 MainLayout
```html
<Router AppAssembly="@typeof(Program).Assembly">
    <Found Context="routeData">
        <RouteView RouteData="@routeData" DefaultLayout="@typeof(MainLayout)" />
    </Found>
    <NotFound>
        <LayoutView Layout="@typeof(MainLayout)">
            <p>Sorry, there's nothing at this address.</p>
        </LayoutView>
    </NotFound>
</Router>
```


### 布局

MainLayout 

```html
<div class="page">
    <div class="sidebar">
        <NavMenu />
    </div>

    <div class="main">
        <div class="top-row px-4">
            <a href="http://blazor.net" target="_blank" class="ml-md-auto">About</a>
        </div>

        <div class="content px-4">
            @Body
        </div>
    </div>
</div>
```

### 导航

NaVMenu 使用了 Bootstrap 组件
* [navbar](https://getbootstrap.com/docs/4.0/components/navbar/)

### 调查页面

使用了 Bootstrap 组件
* [alert](https://getbootstrap.com/docs/4.0/components/alerts/)
* [mt-4](https://getbootstrap.com/docs/4.0/utilities/spacing/#notation)
* [oi-pencil](https://useiconic.com/open)

### 全局引用

_Imports.razor

### Ang Design

官方站点：https://antblazor.com/

GitHub：
https://github.com/ant-design-blazor/ant-design-blazor

演示站点：https://pro.antblazor.com/

Add package
```bash
$ dotnet add package AntDesign
```

Register services
```csharp
builder.Services.AddAntDesign();
```


link static files
```html
<link href="_content/AntDesign/css/ant-design-blazor.css" rel="stylesheet" />
<script src="_content/AntDesign/js/ant-design-blazor.js"></script>
```

add namespace
```
@using AntDesign
```

add ant container
```
<Router AppAssembly="@typeof(MainLayout).Assembly">
    <Found Context="routeData">
        <RouteView RouteData="routeData" DefaultLayout="@typeof(MainLayout)" />
    </Found>
    <NotFound>
        <LayoutView Layout="@typeof(MainLayout)">
            <Result Status="404" />
        </LayoutView>
    </NotFound>
</Router>

<AntContainer />   <-- add this component ✨
```

add a button!
```html
<Button Type="primary">Hello World!</Button>
```

[Blazor Fluent UI](https://www.blazorfluentui.net/)