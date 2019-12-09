- Абстрактная фабрика:
Интерфейс GetReportService позволяет создавать семейство объектов (отчетов), которые затем выводятся с помощью метода PrintReport.
- Строитель:
IDataTransformer - абстрактный интерфейс для создания частей объекта (service). DataTransformer - реализует данный интерфейс. DataTransformerCreator - конструирует объект с помощью интерфейса IDataTransformer.
- Декоратор:
IDataTransformer - базовый класс компонента, чье поведение расширяется базовым классом декоратора ReportServiceTransformerBase. DataTransformer - конкретная реализация компонента. WithDataReportTransformer, VolumeSumReportTransformer и т.д. - конкретные реализации декоратора, добавляющие компоненту новое поведение.
- Приспособленец:
ReportServiceBase – базвый интерфейс, описывающий структуру приспособленцев CsvReportService, TxtReportService, XlsxReportService. DataRow - хранит внешние свойства приспособленца. Report, ReportConfig - – хранят общие свойства приспособленцев. IReportService - создает приспособленцев.