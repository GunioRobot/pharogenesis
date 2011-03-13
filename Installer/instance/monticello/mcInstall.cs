mcInstall

	| repository sortMczs files fileToLoad  version detectFileBlock  count |

	self logCR: 'installing ', self package asString, '...'.

	self package isString ifTrue: [ detectFileBlock := [ :file | file beginsWith: self package ] ].
	(self package isKindOf: Array) 
			ifTrue: [ detectFileBlock :=  [ :file | (self package detect: [ :item | file beginsWith: item ] ifNone: [ false ]) ~= false ] ].
	self package isBlock ifTrue: [ detectFileBlock := self package ].
  

	repository := self mcRepository.

	sortMczs := [:a :b | 
        	[(a findBetweenSubStrs: #($.)) allButLast last asInteger > (b findBetweenSubStrs: #($.)) allButLast last asInteger] on: Error do: [:ex | false]].

	"several attempts to read files - repository readableFileNames sometimes fails"

	count := 0. fileToLoad := nil.
	
	[count := count + 1.
	 (fileToLoad = nil) and:[ count < 5 ] ] 
		whileTrue: [
						files := repository readableFileNames asSortedCollection: sortMczs.
						fileToLoad := files detect: detectFileBlock ifNone: [ nil ].
																						].

	version := repository versionFromFileNamed: fileToLoad.
	version workingCopy repositoryGroup addRepository: repository.
	repository creationTemplate: 'MCHttpRepository
        	location: ''', self mcUrl, '''
        	user: ''', self user, '''
        	password: ''', self password, ''''.
	self log: ' ', version fileName, '...'.

	self withAnswersDo: [ version load ].

	self log: 'done'.
