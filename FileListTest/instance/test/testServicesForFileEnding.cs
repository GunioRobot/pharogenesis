testServicesForFileEnding
	"(self selector: #testServicesForFileEnding) debug"

	self assert: (((FileList new directory: FileDirectory default; yourself) itemsForFile: 'aaa.kkk') anySatisfy: [ :ea | self checkIsServiceIsFromDummyTool: ea ]).
