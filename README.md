# dqxEnthuse

a dqx language translate assistant


## ˵��

���ǻ���DQX��Ϸ����������һ���򵥷������ֹ��ߣ���OCR��ʽ����Ϸ��ĳ�����������ʶ������󽻸����빤�߷��롣


## ����˵��

��Ŀʹ�� Visual Studio 2019 ���������л����� .Net Framework 4.7.2


## ���ر���õİ汾

���ص�ַ https://github.com/john-guo/dqxEnthuse/releases/download/0.0.1/dqxenthuse.zip


## ʹ��˵��

���Locate�󻮳��Ի���������Ȼ�󹤾߾ͻ��Զ��������ѶԻ�����ʶ�������Text������ʾ����������塣

���߱��������빦�ܣ����Բ�����ҳ���߷��뷽ʽ�õ���������������DeeplΪ��˵����ô�����Զ����롣

�������������deepl����(https://www.deepl.com/translator)��Ȼ���ڿ���̨�����������

`
t=document.getElementsByTagName("textarea")[0];setInterval(()=>window.navigator.clipboard.readText().then(x=>{if(x=='')return;t.value=x;e=document.createEvent('HTMLEvents');e.initEvent('change',false,false);t.dispatchEvent(e);window.navigator.clipboard.writeText('');}), 1000);
`

Ҳ����ͨ��"add favorites"��ʽ�����µ�ַ��ӽ�ȥ����deepl�򿪺��������ַ:

`
javascript:t=document.getElementsByTagName("textarea")[0];setInterval(()=>window.navigator.clipboard.readText().then(x=>{if(x=='')return;t.value=x;e=document.createEvent('HTMLEvents');e.initEvent('change',false,false);t.dispatchEvent(e);window.navigator.clipboard.writeText('');}), 1000);
`

Ȼ�󱣳�deepl��ҳ�����ڼ���״̬�����ߺ���������������ʵʱ���룬���ַ��뷽ʽȱ���Ƿ�����ҳ���ڱ��뱣�ּ����������ֻ���ֱ�����ܲ���Ӱ�죬�ô��ǹ���˷����������ҵ��ɡ�



## ʹ�õ��ĵ�������

OpenCVSharp https://github.com/shimat/opencvsharp

Tesseract-OCR .Net Wrapper https://github.com/charlesw/tesseract/

String Similarity .NET https://github.com/feature23/StringSimilarity.NET
