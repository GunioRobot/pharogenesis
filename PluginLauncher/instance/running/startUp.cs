startUp
	| scriptName loader |

	World ifNotNil: [World install].
	StandardFileStream isRunningAsBrowserPlugin
		ifFalse: [^self].
	scriptName _ self parameterAt: 'src'.
	scriptName isEmpty ifTrue:[^self].
	CodeLoader defaultBaseURL: (self parameterAt: 'Base').

	loader _ PluginCodeLoader new.
	loader loadSourceFiles: (Array with: scriptName).
	(scriptName asLowercase endsWith: '.pr') 
		ifTrue:[loader installProject]
		ifFalse:[loader installSourceFiles].