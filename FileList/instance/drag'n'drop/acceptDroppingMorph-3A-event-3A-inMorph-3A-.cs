acceptDroppingMorph: aTransferMorph event: evt inMorph: dest
	| oldName oldEntry destDirectory newName newEntry baseName response |
	destDirectory _ self dropDestinationDirectory: dest event: evt.
	oldName _ aTransferMorph passenger.
	baseName _ FileDirectory localNameFor: oldName.
	newName _ destDirectory fullNameFor: baseName.
	newName = oldName ifTrue: [ "Transcript nextPutAll: 'same as old name'; cr." ^ true ].
	oldEntry _ FileDirectory directoryEntryFor: oldName.
	newEntry _ FileDirectory directoryEntryFor: newName.
	newEntry ifNotNil: [ | msg |
		msg _ String streamContents: [ :s |
			s nextPutAll: 'destination file ';
				nextPutAll: newName;
				nextPutAll: ' exists already,';
				cr;
				nextPutAll: 'and is ';
				nextPutAll: (oldEntry modificationTime < newEntry modificationTime
					ifTrue: [ 'newer' ] ifFalse: [ 'not newer' ]);
				nextPutAll: ' than source file ';
				nextPutAll: oldName;
				nextPut: $.;
				cr;
				nextPutAll: 'Overwrite file ';
				nextPutAll: newName;
				nextPut: $?
		].
		response _ self confirm: msg.
		response ifFalse: [ ^false ].
	].

	aTransferMorph shouldCopy
		ifTrue: [ self primitiveCopyFileNamed: oldName to: newName ]
		ifFalse: [ directory rename: oldName toBe: newName ].

	self updateFileList; fileListIndex: 0.

	aTransferMorph source model ~= self
		ifTrue: [ aTransferMorph source model updateFileList; fileListIndex: 0 ].
	"Transcript nextPutAll: 'copied'; cr."
	^true