openFile
	| stdFileMenuResult crostic file |
	stdFileMenuResult := (StandardFileMenu new pattern: '*.crostic';
				 oldFileFrom: FileDirectory default) startUpWithCaption: 'Select a Crostic File...' translated.
	stdFileMenuResult
		ifNil: [^ nil].
	file := stdFileMenuResult directory readOnlyFileNamed: stdFileMenuResult name.
	crostic := CrosticPanel newFromFile: file.
	file close.
	(self isClean
			or: [self confirm: 'Is it OK to discard this crostic?' translated])
		ifTrue: [self world
				addMorphFront: (crostic position: self position).
			self delete]
		ifFalse: [self world addMorphFront: crostic]