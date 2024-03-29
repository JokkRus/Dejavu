﻿using UnityEngine;

public static class MainSector
{
   public static int Level = 0;
   public static string[] nameLevel =
    {
        "Военная и ядерная сферы",
        "Медицина",
        "Военная и ядерная сферы",
        "Изобретение",
        "Изобретение",
        "Космос",
        "Космос",
        "Изобретение",
        "Информационные технологии",
        "Изобретение",
        "Изобретение",
        "Военная и ядерная сферы",
        "Информационные технологии",
        "Информационные технологии",
        "Медицина",
        "Информационные технологии"
    };
    public static string[] titleLevel =
    {
        "Первое испытание термоядерного оружия",
        "Расшифровка структуры ДНК",
        "Первая в мире атомная электростанция",
        "Первая интегральная схема",
        "Первый оптический квантовый генератор - лазер",
        "Первый полет в космос",
        "Организация спутниковой связи",
        "Первый промышленный робот",
        "Появление интернета",
        "Первый компактный сотовый телефон",
        "Первый домашний компьютер",
        "Авария на ЧАЭС",
        "Первая поисковая система",
        "Первая операционная система с удобным пользовательским графическим интерфейсом",
        "Первое клонирование",
        "Социальная сеть"
    };
    public static string[] dataLevel =
    {
        "1 ноября 1952 года США взорвали первый в мире термоядерный заряд на атолле Эниветок.12 августа 1953 года в СССР была взорвана первая в мире водородная (не являющаяся в полном смысле именно термоядерной, т.к. большинство выделенной энергии было за счёт распада, а не синтеза. Можно сравнить с действительной термоядерной бомбой в испытании «Bravo» - 400кт vs 15 Мт) бомба — советская РДС-6 наполигоне в Семипалатинске.Устройство, испытанное США в 1952 году, фактически не являлось бомбой, а представляло собой лабораторный образец, «3-этажный дом, наполненный жидким дейтерием», выполненный в виде специальной конструкции. Советские же учёные разработали именно бомбу — законченное устройство, пригодное к практическому военному применению.",
        "Структура двойной спирали ДНК была предложена Френсисом Криком и Джеймсом Уотсоном в 1953 году на основании рентгеноструктурных данных, полученных Морисом Уилкинсом и Розалинд Франклин, и «правил Чаргаффа», согласно которым в каждой молекуле ДНК соблюдаются строгие соотношения, связывающие между собой количество азотистых оснований разных типов. Позже предложенная Уотсоном и Криком модель строения ДНК была доказана, а их работа отмечена Нобелевской премией по физиологии или медицине 1962 г. Среди лауреатов не было скончавшейся к тому времени от рака Розалинд Франклин, так как премия не присуждается посмертно.Интересно, что в 1957 году американцы Александер Рич, Гэри Фелзенфелд и Дэйвид Дэйвис описали нуклеиновую кислоту, составленную тремя спиралями. А в 1985—1986 годах Максим Давидович Франк-Каменецкий в Москве показал, как двухспиральная ДНК складывается в так называемую H-форму, составленную уже не двумя, а тремя нитями ДНК.",
        "Первая в мире промышленная атомная электростанция мощностью 5 МВт была запущена 27 июня 1954 года в СССР, в городе Обнинске, расположенном в Калужской области. В 1958 году была введена в эксплуатацию 1-я очередь Сибирской АЭС мощностью 100 МВт, впоследствии полная проектная мощность была доведена до 600 МВт. В том же году развернулось строительство Белоярской промышленной АЭС, а 26 апреля 1964 года генератор 1-й очереди дал ток потребителям. В сентябре 1964 года был пущен 1-й блок Нововоронежской АЭС мощностью 210 МВт. Второй блок мощностью 365 МВт запущен в декабре 1969 года. В 1973 году запущена Ленинградская АЭС.",
        "В конце 1958 года и в первой половине 1959 года в полупроводниковой промышленности состоялся прорыв. Три человека, представлявшие три частные американские корпорации, решили три фундаментальные проблемы, препятствовавшие созданию интегральных схем. Джек Килби из Texas Instruments запатентовал принцип объединения, создал первые, несовершенные, прототипы ИС и довёл их до серийного производства. Курт Леговец из Sprague Electric Company изобрёл способэлектрической изоляции компонентов, сформированных на одном кристалле полупроводника (изоляцию p-n-переходом (англ. P–n junction isolation)). Роберт Нойс из Fairchild Semiconductor изобрёл способ электрического соединения компонентов ИС (металлизацию алюминием) и предложил усовершенствованный вариант изоляции компонентов на базе новейшей планарной технологии Жана Эрни (англ. Jean Hoerni). 27 сентября 1960 года группа Джея Ласта (англ. Jay Last) создала на Fairchild Semiconductor первую работоспособную полупроводниковую ИС по идеям Нойса и Эрни. Texas Instruments, владевшая патентом на изобретение Килби, развязала против конкурентов патентную войну, завершившуюся в 1966 году мировым соглашением о перекрёстном лицензировании технологий.",
        "1960 год: 16 мая Т. Мейман продемонстрировал работу первого оптического квантового генератора — лазера. В качестве активной среды использовался кристаллискусственного рубина (оксид алюминия Al2O3 с небольшой примесью хрома Cr), а вместо объёмного резонатора служил резонатор Фабри-Перо, образованный серебряными зеркальными покрытиями, нанесёнными на торцы кристалла. Этот лазер работал в импульсном режиме на длине волны 694,3 нм. В декабре того же года был создан гелий-неоновый лазер, излучающий в непрерывном режиме (А. Джаван, У. Беннет, Д. Хэрриот). Изначально лазер работал в инфракрасном диапазоне, затем был модифицирован для излучения видимого красного света с длиной волны 632,8 нм.",
        "12 апреля 1961 года Юрий Гагарин стал первым человеком в мировой истории, совершившим полёт в космическое пространство. Ракета-носитель «Восток» с кораблём «Восток-1», на борту которого находился Гагарин, была запущена с космодрома Байконур. После 108 минут полёта Гагарин успешно приземлился в Саратовской области, неподалёку от города Энгельса. Начиная с 12 апреля 1962 года, день полёта Гагарина в космос был объявлен праздником — Днём космонавтики.",
        "20 августа 1964 года 11 стран (СССР в их число не вошёл) подписали соглашение о создании международной организации спутниковой связи Intelsat (International Telecommunications Satellite organization). В СССР к тому времени была собственная развитая программа спутниковой связи, увенчавшаяся 23 апреля 1965 года успешным запуском связного советского спутника Молния-1.",
        "Японская компания Kawasaki Heavy Industries, Ltd. получила лицензию на производство робота от американской фирмы Unimation Inc. и собрала своего первого промышленного робота. С тех пор Япония начала неуклонное движение к тому, чтобы стать мировой столицей роботов — с более чем 130 компаниями, вовлеченных в их производство. Изначально сконструированные в США, первые роботы Японии импортировались в малых количествах. Инженеры изучали их и применяли в производстве в таких специфических работах, как сварка и распыление. В 70-х годах были разработаны многочисленные возможности практического применения в данной области. 1980 — коммерческое начало для роботов, производимых на основе высоких технологий (Япония). С этого момента рынок начал расти.",
        "Разработка такой сети была поручена Калифорнийскому университету в Лос-Анджелесе, Стэнфордскому исследовательскому центру, Университету Юты и Университету штата Калифорния в Санта-Барбаре. Компьютерная сеть была названа ARPANET (англ. Advanced Research Projects Agency Network), и в 1969 году в рамках проекта сеть объединила четыре указанных научных учреждения. Все работы финансировались Министерством обороны США. Затем сеть ARPANET начала активно расти и развиваться, её начали использовать учёные из разных областей науки.Первый сервер ARPANET был установлен 2 сентября 1969 года в Калифорнийском университете (Лос-Анджелес). 29 октября 1969 года в 21:00 между двумя первыми узлами сети ARPANET, находящимися на расстоянии в 640 км провели сеанс связи. Чарли Клайн (Charley Kline) пытался выполнить удалённое подключение из Лос-Анджелеса к компьютеру в Стэнфорде. Успешную передачу каждого введённого символа его коллега Билл Дювалль (Bill Duvall) из Стэнфорда подтверждал по телефону.В первый раз удалось отправить всего два символа «LO» после чего сеть перестала функционировать. LO должно было быть словом LOGIN (команда входа в систему). В рабочее состояние систему вернули уже к 22:30, и следующая попытка оказалась успешной. Именно эту дату можно считать днём рождения интернета.",
        "В 1973 году был выпущен первый прототип портативного сотового телефона — Motorola DynaTAC. Считается, что первый звонок по этому телефону был сделан 3 апреля 1973 года, когда его изобретатель, сотрудник Motorola Мартин Купер, позвонил конкуренту из AT&T, Джоэлю Энгелю. DynaTAC весил около 1,15 кг и имел размер 22,5×12,5×3,75 см. На его передней панели было расположено 12 клавиш — 10 цифровых и две для отправки вызова и прекращения разговора. У DynaTAC-а отсутствовал дисплей и не было никаких дополнительных функций. В режиме ожидания он мог работать до восьми часов, в режиме разговора около часа (по другим данным, 35 минут); заряжать его приходилось чуть более 10 часов. До 1983 года было создано 5 прототипов DynaTAC.",
        "Компьютер был впервые представлен в 1977 году на выставке West Coast Computer Fair и стал одним из самых первых и наиболее успешных персональных компьютеров того времени. Производилось несколько моделей Apple II, и наиболее популярная из них, с относительно небольшими изменениями, продавалась до 1990-х. Всего было произведено от 5 до 6 миллионов экземпляров Apple II. В отличие от других машин того времени, Apple II выглядел более похожим на офисный инструмент, чем на элемент электронного оборудования. Это был компьютер, который подходил для домашней обстановки, стола менеджера или школьного класса.Также уникальным для того времени было использование цвета и графических режимов высокого разрешения, его звуковых возможностей, а также встроенного языка программирования Бейсик. По сравнению с более ранними машинами, эти возможности были хорошо документированы и просты в изучении. Тем самым, Apple II обозначил начало революции в области персональных компьютеров: это была машина для обычных людей, а не только для любителей, учёных или инженеров.",
        "Авария на Черно́быльской АЭС — разрушение 26 апреля 1986 года четвёртого энергоблока Чернобыльской атомной электростанции, расположенной на территории Украинской ССР (ныне —Украина). Авария расценивается как крупнейшая в своём роде за всю историю атомной энергетики, как по предполагаемому количеству погибших и пострадавших от её последствий людей, так и по экономическому ущербу.  Для ликвидации последствий были мобилизованы значительные ресурсы,более 600 тыс. человек участвовали в ликвидации последствий аварии. Облако, образовавшееся от горящего реактора, разнесло различные радиоактивные материалы, и прежде всего радионуклиды иода и цезия, по большей части территории Европы. Наибольшие выпадения отмечались на значительных территориях в Советском Союзе, расположенных вблизи реактора и относящихся теперь к территориям Республики Беларусь, Российской Федерации и Украины.Чернобыльская авария стала событием большого общественно-политического значения для СССР. Всё это наложило определённый отпечаток на ход расследования её причин. Подход к интерпретации фактов и обстоятельств аварии менялся с течением времени, и полностью единого мнения нет до сих пор.",
        "Первой полнотекстовой индексирующей ресурсы при помощи робота («craweler-based») поисковой системой, стала система «WebCrawler», запущенная в 1994 году. В отличие от своих предшественниц она позволяла пользователям искать по любым словам, расположенным на любой веб-странице — с тех пор это стало стандартом для большинства поисковых систем. Кроме того, это был первый поисковик, получивший широкое распространение. В 1994 году была запущена система «Lycos», разработанная в Университете Карнеги-Меллон и ставшая серьёзным коммерческим предприятием.",
        "Выпущенная в сентябре 1995 г. система Windows 95 стала первой графической операционной системой для компьютеров IВМ РС.Все следующие версии операционных систем Windows (98, NT, ME, 2000, XP) являются графическими. (Бил Гейтс)",
        "Овца До́лли (англ. Dolly, 5 июля 1996 — 14 февраля 2003) — первое клонированное млекопитающее животное, которое было получено путём пересадки ядра соматической клетки в цитоплазму яйцеклетки. Овца Долли являлась генетической копией овцы-донора клетки.Генетическая информация для процесса клонирования была взята из взрослых дифференцированных (соматических) клеток, а не из половых (гамет) или стволовых. Самого исходного животного (прототипа) на момент клонирования уже не существовало. А часть его клеток, необходимая для эксперимента, была своевременнозаморожена и хранилась в жидком азоте, чтобы сохранить и передать генетический материал.Эксперимент был поставлен Яном Вилмутом (англ. Ian Wilmut) и Китом Кэмпбеллом в Рослинском институте (англ. Roslin Institute), в Шотландии, близ Эдинбурга в 1996 году. Эксперимент считается прорывом в технологиях, сравнимым с расщеплением атома.Сама Долли стала самой известной овцой в истории науки. Она прожила 6,5 лет и оставила после себя 6 ягнят. Долли была усыплена в 2003 году.",
        "Facebook («Фейсбу́к», [ˈfeɪsˌbʊk]) — одна из крупнейших социальных сетей в мире. Была основана 4 февраля 2004 года Марком Цукербергом и его соседями по комнате во время обучения в Гарвардском университете — Эдуардо Саверином,Дастином Московицем и Крисом Хьюзом. Первоначально веб-сайт был назван Thefacebook и был доступен только для студентов Гарвардского университета, затем регистрацию открыли для других университетов Бостона, а затем и для студентов любых учебных учреждений США, имеющих электронный адрес в домене .edu. Начиная с сентября 2006 года сайт доступен для всех пользователей Интернета в возрасте от 16 лет, имеющих адрес электронной почты."
    };
    public static string[] standardWay =
    {
        "США и СССР активно учавствуют в разработке термоядерной бомбы",
        "Расшифровка структуры ДНК",
        "Построить первую атомную электростанцию",
        "Разработать интегральную схему",
        "Разработать первый лазер",
        "Полететь на орбиту Земли",
        "Создать международную организацию спутниковой связи",
        "Разработать первого промышленного робота",
        "Открыть интернет",
        "Выпустить первый прототип портативного сотового телефона",
        "Разработать Apple II",
        "Провести тест четвертого энерго-блока ЧАЭС",
        "Разработать поисковую систему WebCrawler",
        "Разработать Windows с графическим интерфейсом",
        "Клонировать животное",
        "Разработать Facebook"
    };
    public static string[] upgradeWay =
    {
        "Производится запрет термоядерного оружия",
        "Изучение полезных свойств ДНК",
        "Глубоко изучить стабилизацию в управлении реакторами",
        "Разработать микропроцессоры",
        "Изучение гелий-неоновых лазеров для медицинских целей",
        "Полететь на Луну",
        "Сделать единую международную спутниковую связь",
        "Разработать первого интеллектуального робота",
        "Открыть интернет и возможность его беспроводного использования",
        "Изучить работу сотовых сетей и выпустить итоговую модель телефона",
        "Разработать IBM PC",
        "Остановить тест энергоблока, выявить недостатки реактора",
        "Разработать поисковую систему Google",
        "Развивать платформу Linux",
        "Клонировать человека",
        "Разработать комплекс интеррактивной информации"
    };
    public static string[] downgradeWay =
    {
        "США и СССР неудачно испытывают термоядерное оружие",
        "Изучение влияния на ДНК (мутация)",
        "Построить новые ядерные бомбы высокой мощности",
        "Увеличение количества процессоров с использованием электромеханических реле, ферритовых сердечников и вакуумных ламп",
        "Реализовать программу Терра и Омега (военные цели)",
        "Преодолеть атмосферу Земли",
        "Сделать обособленные друг от друга спутниковые связи",
        "Разработать первого военного робота",
        "Запретить разработку интернета",
        "Использовать базовую станцию для сотовых телефонов",
        "Распространить Apple I",
        "Не проводить тест энергоблока",
        "Сделать поисковые системы по запросу",
        "Разработать Macintosh с удобным графическим интерфейсом",
        "Клонировать вирус",
        "Посадить Марка Цукерберга за нарушение авторских прав"
    };
    public static byte[] standardRunTime =
    {
        0,
        1,
        1,
        4,
        2,
        1,
        3,
        4,
        1,
        4,
        4,
        9,
        8,
        1,
        1,
        8
    };
    public static byte[] fasterRunTime =
    {
        0,
        1,
        1,
        4,
        2,
        1,
        3,
        4,
        1,
        4,
        4,
        9,
        8,
        1,
        1,
        8
    };
    public static byte[] slowerRunTime =
    {
        0,
        1,
        1,
        4,
        2,
        1,
        3,
        4,
        1,
        4,
        4,
        9,
        8,
        1,
        1,
        8
    };
}
