acceptDroppingMorph: aTransferMorph event: evt inMorph: dest
	| oldName oldEntry destDirectory newName newEntry baseName response |
	destDirectory := self dropDestinationDirectory: dest event: evt.
	oldName := aTransferMorph passenger.
	baseName := FileDirectory localNameFor: oldName.
	newName := destDirectory fullNameFor: baseName.
	newName = oldName ifTrue: [ "Transcript nextPutAll: 'same as old name'; cr." ^ true ].
	oldEntry := FileDirectory directoryEntryFor: oldName.
	newEntry := FileDirectory directoryEntryFor: newName.
	newEntry ifNotNil: [ | msg |
		msg := String streamContents: [ :s |
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
		response := self confirm: msg.
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