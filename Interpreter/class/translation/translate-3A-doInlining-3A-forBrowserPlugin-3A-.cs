translate: fileName doInlining: inlineFlag forBrowserPlugin: pluginFlag
	"Note: The pluginFlag is meaningless on Windows and Unix. On these platforms Squeak runs as it's own process and doesn't need any special attention from the VMs point of view. Meaning that NONE of the required additional functions will be supported. In other words, the pluginFlag is not needed and not supported."
	"Translate the Smalltalk description of the virtual machine into C. If inlineFlag is true,
small method bodies are inlined to reduce procedure call overhead. On the PPC, this results in a factor of three speedup with only 30% increase in code size. If pluginFlag is true, generate code for an interpreter that runs as a browser plugin (Netscape or IE)."

	| doInlining cg exports |
	doInlining _ inlineFlag.
	pluginFlag ifTrue: [doInlining _ true].  "must inline when generating browser plugin"
	Interpreter initialize.
	ObjectMemory initialize.
	GenerateBrowserPlugin _ pluginFlag.
	cg _ CCodeGenerator new initialize.
	cg addClass: Interpreter.
	cg addClass: ObjectMemory.
	Interpreter declareCVarsIn: cg.
	ObjectMemory declareCVarsIn: cg.
	"Get all the named prims from the VM.
	Note: the format of exports is:
		pluginName -> Array of: primitiveName.
	so we can generate a nice table from it."
	exports _ Array with: '' -> cg exportedPrimitiveNames asArray.
	cg storeCodeOnFile: fileName doInlining: doInlining.
	"Add our plugins"
	{
		"Graphics"
			"Note: BitBltSimulation should go first, 
			because three of it's entries might be 
			looked up quite often (due to refs from 
			InterpreterProxy). This will go away at
			some point but for now it's a good idea
			to have those entries early in the table."
		BitBltSimulation.	
		BalloonEnginePlugin. 
		SurfacePlugin. "To support OS surfaces through FXBlt"

		"I/O subsystems"
		FilePlugin.
		SocketPlugin.
		MIDIPlugin. 
		SerialPlugin. 
		JoystickTabletPlugin. 
		AsynchFilePlugin. 

		"Sound"
		SoundPlugin. 
		SoundGenerationPlugin.
		ADPCMCodecPlugin.
		KlattSynthesizerPlugin.
		SoundCodecPlugin.

	 	"Numerics"
		LargeIntegersPlugin.
		FFTPlugin. 
		FloatArrayPlugin. 
		Matrix2x3Plugin. 

		"Compression"
		DeflatePlugin.

		"Others"
		B3DEnginePlugin.
		DSAPlugin.
		DropPlugin. 
		MiscPrimitivePlugin.

		"Note: Optionally, you can translate the following as builtins.
		As of Squeak 2.7 they are not builtins by default:
			FFIPlugin.
		"
	} do:[:plugin|
		cg _ plugin translate: plugin moduleName, '.c'
					doInlining: doInlining
					locally: true.
		exports _ exports copyWith: 
			(plugin moduleName -> cg exportedPrimitiveNames asArray).
	].
	self storeExports: exports on: 'sqNamedPrims.h'.