compositionWindowManager
	CompositionWindowManager ifNotNil: [^CompositionWindowManager].
	SmalltalkImage current  platformName = 'Win32' 
		ifTrue: [^CompositionWindowManager := ImmWin32 new].
	(SmalltalkImage current  platformName = 'unix' 
		and: [(SmalltalkImage current  getSystemAttribute: 1005) = 'X11']) 
			ifTrue: [^CompositionWindowManager := ImmX11 new].
	^CompositionWindowManager := ImmAbstractPlatform new