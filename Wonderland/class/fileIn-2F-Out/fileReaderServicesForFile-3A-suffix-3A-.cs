fileReaderServicesForFile: fullName suffix: suffix

	^(suffix = 'wrl') | (suffix = '*') 
		ifTrue: [ Array with: self serviceOpenInWonderland]
		ifFalse: [(suffix = 'mdl') | (suffix = '*')
					ifTrue: [ Array with: self serviceOpenModelInEditor]
					ifFalse: [#()]]
