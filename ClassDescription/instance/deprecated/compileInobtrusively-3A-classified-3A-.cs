compileInobtrusively: code classified: category
	"Compile the code and classify the resulting method in the given category, leaving no trail in  the system log, nor in any change set, nor in the 'recent submissions' list.  This should only be used when you know for sure that the compilation will succeed."

	| methodNode newMethod |
	self deprecated: 'Use compileSilently:classified: instead.'.
	
	methodNode _ self compilerClass new compile: code in: self notifying: nil ifFail: [^ nil].
	self addSelectorSilently: methodNode selector withMethod: (newMethod _ methodNode generate: #(0 0 0 0)).
	SystemChangeNotifier uniqueInstance doSilently: [self organization classify: methodNode selector under: category].
	^ newMethod