thumbnailFromUrl: urlString

	| fileStream |
	"Load the project, and make a thumbnail to it in the current project.
Project thumbnailFromUrl: 'http://www.squeak.org/Squeak2.0/2.7segments/SqueakEasy.extSeg'.
"

	Project canWeLoadAProjectNow ifFalse: [^ self].
	ComplexProgressIndicator new 
		targetMorph: nil;
		historyCategory: 'project loading';
		withProgressDo: [
			fileStream _ (Project serverFileFromURL: urlString) asStream.
			ProjectLoading
				openFromFile: fileStream
				fromDirectory: nil
				withProjectView: nil.
		]

