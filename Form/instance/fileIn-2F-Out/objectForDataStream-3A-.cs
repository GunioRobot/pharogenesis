objectForDataStream: refStream
	| prj repl |
	prj _ refStream project.
	prj ifNil:[^super objectForDataStream: refStream].
	ResourceCollector current ifNil:[^super objectForDataStream: refStream].
	repl _ ResourceCollector current objectForDataStream: refStream fromForm: self.
	^repl