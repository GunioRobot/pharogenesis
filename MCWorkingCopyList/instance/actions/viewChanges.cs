viewChanges
	| patch |
	self canSave ifTrue:
		[patch _ workingCopy changesRelativeToRepository: self repository.
		patch isNil ifTrue: [^ self].
		patch isEmpty
			ifTrue: [self inform: 'No changes'. workingCopy modified: false ]
			ifFalse:
				[(MCPatchBrowser forPatch: patch)
					label: 'Patch Browser: ', workingCopy description;
					show]]