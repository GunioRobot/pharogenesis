testService
	"a stupid test to check that the class returns a service"
	"(self selector: #testService) debug"
	
	| service |
	service := (DummyToolWorkingWithFileList fileReaderServicesForFile: 'abab.kkk' suffix: 'kkk') first.
	self assert: (self checkIsServiceIsFromDummyTool: service).
	service := (DummyToolWorkingWithFileList fileReaderServicesForFile: 'zkk.gz' suffix: 'gz').
	self assert: service isEmpty