cleanseScripts
	"Fix up various known structure errors in the uniclass relating to the scripts dctionary.  Answer the number of fixes made."

	| errs ed |
	scripts ifNil: [scripts _ IdentityDictionary new].
	errs _ 0.
	(scripts includesKey: nil) ifTrue: [errs _ errs + 1.  scripts removeKey: nil].
	scripts keysAndValuesDo: 
		[:sel :uniclassScript |
			uniclassScript
				ifNil:
					[errs _ errs + 1.
					Transcript cr; show: ' fix type 1, nil scripts key'.
					scripts removeKey: sel]
				ifNotNil:
					[(ed _ uniclassScript currentScriptEditor)
						ifNil:
							[errs _ errs + 1.
							Transcript cr; show: ' fix type 2, sel = ', sel.
							self someInstance removeScriptWithSelector: uniclassScript selector.]
						ifNotNil:
							[uniclassScript playerClassPerSe
								ifNil:
									[errs _ errs + 1.
									Transcript cr; show: ' fix type 3, sel = ', sel.
									uniclassScript playerClass: self selector:  sel]
								ifNotNil:
									[(ed scriptName ~= uniclassScript selector) ifTrue:
										[errs _ errs + 1.
										ed restoreScriptName: sel.
										Transcript cr; show: ' fix type 4, sel = ', sel.]]]]].
	^ errs