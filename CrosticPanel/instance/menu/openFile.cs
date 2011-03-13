openFile

	| stdFileMenuResult crostic file |
	stdFileMenuResult _ ((StandardFileMenu new) pattern: '*.crostic'; 
		oldFileFrom: FileDirectory default ) 
			startUpWithCaption: 'Select a Crostic File...'.
	stdFileMenuResult ifNil: [^ nil].
	file _ stdFileMenuResult directory readOnlyFileNamed: stdFileMenuResult name.
	crostic _ CrosticPanel newFromFile: file.  file close.
	(self isClean or: [self confirm: 'Is it OK to discard this crostic?'])
		ifTrue: [self world addMorphFront: (crostic position: self position).
				self delete]
		ifFalse: [self world addMorphFront: crostic].

