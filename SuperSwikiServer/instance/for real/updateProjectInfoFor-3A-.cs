updateProjectInfoFor: aProject

	| data details projectLinks linkString uploader |

	data _ OrderedCollection new.
	data add: 'action: updatepage'.
	data add: 'projectimage: ',aProject name,'.gif'.
	uploader _ Utilities authorNamePerSe.
	uploader isEmptyOrNil ifTrue: [uploader _ Utilities authorInitialsPerSe].
	uploader isEmptyOrNil ifFalse: [
		data add: 'submittedBy: ',uploader.
	].
	projectLinks _ Set new.
	aProject world allMorphsDo: [ :each |
		(each isKindOf: ProjectViewMorph) ifTrue: [
			projectLinks add: each safeProjectName.
		].
	].
	details _ aProject world valueOfProperty: #ProjectDetails ifAbsent: [Dictionary new].
	details at: 'projectname' ifAbsentPut: [aProject name].
	projectLinks isEmpty ifTrue: [
		details removeKey: 'projectlinks' ifAbsent: []
	] ifFalse: [
		linkString _ String streamContents: [ :strm |
			projectLinks asSortedCollection do: [ :each |
				strm nextPutAll: each
			] separatedBy: [
				strm nextPut: $.
			].
		].
		details at: 'projectlinks' put: linkString
	].
	details keysAndValuesDo: [ :k :v |
		data add: k , ': ' , v
	].
	^self sendToSwikiProjectServer: data.
