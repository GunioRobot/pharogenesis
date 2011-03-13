browseClassVariables
	"Request a browser on the class variables of the selected class.  2/1/96 sw"

	| aClass |
	self controlTerminate.
	(aClass _ model selectedClassOrMetaClass) notNil ifTrue: 
		[aClass browseClassVariables].
	self controlInitialize