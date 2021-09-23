
# UrlMapper


> *"Understands" Urls and "Manipulate" them*

UrlMapper is a containerized microservice that solves mapping problem between web url and mobile url 
Also it could be extended with new business requirements such as permanent redirection, sitemap generation etc.

### Technology Stack
- Asp.Net Core
- Net 5
- ELK (for logging)
- Redis (master db)
- Serilog 
- xUnit 

### Requirements
- Visual Studio.2019 (to debug)
- Docker Desktop must be installed



### Test

- open UrlMap.sln 
- Run All Test in TestExplorer Window

### Ubiquitous Language / Data Dictionary

| Term        | Definition
| ------------- |:-------------:|
| WebUrl       | `https://www.oz.com/casio/watch-p-1925865` |
| MobileUrl (Deeplink)      | `oz://?Page=Product&ContentId=1925865`      |
| WebUri | object form of WebUrl      |
| MobileUri | object form of MobileUrl |
| Route | object form of Segment+Query+Fragment |
| IWebPage | endpoint model of web requests |
| IMobilePage | endpoint model of mobile requests |
| Scheme, Authority, Path, Query, Fragment |  |
| Segment | each item when we seperate Path with `/`



