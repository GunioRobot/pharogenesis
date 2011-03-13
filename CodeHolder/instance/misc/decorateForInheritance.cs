decorateForInheritance
	"Check to see if the currently-viewed method has a super send or an override, and if so, change screen feedback, unless the #decorateBrowserButtons says not to."

	| aColor aButton |
	(aButton _ self inheritanceButton) ifNil: [^ self].

	aColor _ (currentCompiledMethod == nil or: [Preferences decorateBrowserButtons not])
		ifTrue:
			[Color transparent]
		ifFalse:
			[currentCompiledMethod sendsToSuper
				ifTrue:
					[self isThereAnOverride
						ifTrue:
							[Color blue muchLighter]
						ifFalse:
							[Color green muchLighter ]]
				ifFalse:
					[self isThereAnOverride
						ifTrue:
							[Color tan lighter]
						ifFalse:
							[Color transparent]]].
	aButton offColor: aColor