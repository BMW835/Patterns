- Абстрактная фабрика:
Интерфейс GetReportService позволяет создавать семейство объектов (отчетов), которые затем выводятся с помощью метода PrintReport.
- Строитель:
IDataTransformer - абстрактный интерфейс для создания частей объекта (service). DataTransformer - реализует данный интерфейс. DataTransformerCreator - конструирует объект с помощью интерфейса IDataTransformer.
- Декоратор:
IDataTransformer - базовый класс компонента, чье поведение расширяется базовым классом декоратора ReportServiceTransformerBase. DataTransformer - конкретная реализация компонента. WithDataReportTransformer, VolumeSumReportTransformer и т.д. - конкретные реализации декоратора, добавляющие компоненту новое поведение.
- Приспособленец:
ReportServiceBase – базвый интерфейс, описывающий структуру приспособленцев CsvReportService, TxtReportService, XlsxReportService. DataRow - хранит внешние свойства приспособленца. Report, ReportConfig - – хранят общие свойства приспособленцев. IReportService - создает приспособленцев.
- Мост:
Реализовано две отдельные иерархии классов - от IDataTransformer и IReportService.


Предложения:
- к report и Transformer добавить Декоратор, что позволит гибко присваивать выводу новые возможости в зависимости от заявленных опций.
- Добавить Services Состояние, чтобы изменять поведение в зависимости от типа файла.
- Объединить объекты GetReportService, Report, PrintReport в Фасад.

Реализация:
- GetReportService преобразован в Цепочку обязанностей, что позволяет обрабатывать тип файла несколькими объектами.