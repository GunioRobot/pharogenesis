cleanUpForProduction
	| oldDicts newDicts |
	
	"trim MC ancestory information"
	MCVersionInfo allInstances do: [ :each | each instVarNamed: 'ancestors' put: nil ].
	
	"delete logo"
	(World submorphs detect: [:m | m class = SketchMorph]) delete.
	
	"delete ScriptLoader log"
	ScriptLoader resetLogStream.
	
	"unload all test packages"
	#(Tests CollectionsTests CompilerTests FreeTypeTests GraphicsTests KernelTests MorphicTests MultilingualTests NetworkTests ToolsTest)
		do: [ :each | (MCPackage named: each) unload ].
	
	"unload SUnit"
	Smalltalk at: #TestCase ifPresent: [ :class |
		SystemChangeNotifier uniqueInstance noMoreNotificationsFor: class ].
	#(SUnitGUI SUnit) do: [ :each | (MCPackage named: each) unload ].
	AppRegistry removeObsolete.
	TheWorldMenu removeObsolete.
	
	"shrink method dictionaries."
	Smalltalk garbageCollect.
	oldDicts := MethodDictionary allInstances.
	newDicts := Array new: oldDicts size.
	oldDicts withIndexDo: [:d :index | newDicts at: index put: d rehashWithoutBecome ].
	oldDicts elementsExchangeIdentityWith: newDicts.
	oldDicts := newDicts := nil.
	
	3 timesRepeat: [
		Smalltalk garbageCollect.
		Symbol compactSymbolTable ]