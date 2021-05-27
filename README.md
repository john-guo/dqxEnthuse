# dqxEnthuse

a dqx language translate assistant


## 说明

这是基于DQX游戏热情制作的一个简单翻译助手工具，用OCR方式把游戏内某个区域的文字识别出来后交给翻译工具翻译。


## 编译说明

项目使用 Visual Studio 2019 开发，运行环境是 .Net Framework 4.7.2


## 下载编译好的版本

下载地址 https://github.com/john-guo/dqxEnthuse/releases/download/0.0.1/dqxenthuse.zip


## 使用说明

点击Locate后划出对话所在区域，然后工具就会自动工作，把对话文字识别出放入Text窗口显示并存入剪贴板。

工具本身不带翻译功能，可以采用网页在线翻译方式得到翻译结果，这里以Deepl为例说明怎么进行自动翻译。

首先用浏览器打开deepl官网(https://www.deepl.com/translator)，然后在控制台运行以下命令：

`
t=document.getElementsByTagName("textarea")[0];setInterval(()=>window.navigator.clipboard.readText().then(x=>{if(x=='')return;t.value=x;e=document.createEvent('HTMLEvents');e.initEvent('change',false,false);t.dispatchEvent(e);window.navigator.clipboard.writeText('');}), 1000);
`

也可以通过"add favorites"方式把以下地址添加进去并在deepl打开后点击这个地址:

`
javascript:t=document.getElementsByTagName("textarea")[0];setInterval(()=>window.navigator.clipboard.readText().then(x=>{if(x=='')return;t.value=x;e=document.createEvent('HTMLEvents');e.initEvent('change',false,false);t.dispatchEvent(e);window.navigator.clipboard.writeText('');}), 1000);
`

然后保持deepl网页窗口在激活状态，工具和浏览器间就能联动实时翻译，这种翻译方式缺点是翻译网页窗口必须保持激活，这样导致只有手柄玩家能不受影响，好处是规避了翻译软件的商业许可。



## 使用到的第三方库

OpenCVSharp https://github.com/shimat/opencvsharp

Tesseract-OCR .Net Wrapper https://github.com/charlesw/tesseract/

String Similarity .NET https://github.com/feature23/StringSimilarity.NET
