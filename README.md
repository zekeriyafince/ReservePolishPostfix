# ReservePolishPostfix
Infix to Postfix Conversion and Calculation


**- Genel Olarak;**


Bilgisayarda 3 x 4 + 5 vb. aritmetik ifadeleri çözümlemek zor olabilir. Yazacağımız kodda, işlem öncelikleri ve parantezler ifade sonucunu bulmayı zorlaştırabilir. Bu yüzden, aritmetik ifadeleri göstermek için farklı notasyonlar geliştirilmiştir.

*- Infix Notasyonu*

Halihazırda kullandığımız notasyondur. 3 + 4 örneğinde olduğu gibi, operatörler ifade içerisindedir.

3 + 4 x 5 örneğinde olduğu gibi, operatörler arasında işlem önceliği vardır. Verilen örnekte, ilk olarak çarpma işlemi, ardından toplama işlemi yapılır.

İşlem sırasını değiştirmek için parantezler kullanılır. Örneğin, (3 + 4) x 5

*- Postfix Notasyonu (Reverse Polish Notation)*

34+ örneğinde olduğu gibi operatörler, işleme sokulacak ifadelerin sonrasına yazılır. Verilen örnekte, iki sayı toplanmak istenmektedir.

345x+ örneğinde olduğu gibi, operatörler arasında işlem önceliği vardır. Verilen örnekte, ilk olarak çarpma işlemi, ardından, bulunan çarpım sonucu ile toplama işlemi yapılır. (Daha anlaşılır olması için 345x+ ifadesini 3[45x]+ şeklinde anlayabiliriz.)

İşlem önceliğini değiştirmek için parantez kullanmak gerekmez. Örneğin, (3 + 4) x 5 ifadesi 34+5x şeklinde ifade edilir. Toplama işlemi yapıldıktan sonra, bulunan toplam sonucuna çarpma işlemi uygulanır. 

Tüm notasyonlarda işlem önceliği; parantez, üs alma, çarpma / bölme, toplama / çıkarma şeklindedir. Aynı işlem önceliğine sahip birden fazla ifadenin gelmesi durumunda, üs alma hariç, soldan sağa doğru işlemler yapılır.

-> DLL yapısını projede yuklemek icin; 
 - [DllYuklemeMain.cs](https://github.com/zekeriyafince/ReservePolishPostfix/blob/master/DllYuklemeMain.cs)  main kısmında ornek kullanım yapildi.


