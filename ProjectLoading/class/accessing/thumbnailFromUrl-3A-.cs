thumbnailFromUrl: urlString

	| fileName fileAndDir |

	"Load the project, and make a thumbnail to it in the current project.
ProjectLoading thumbnailFromUrl: 'http://www.squeak.org/Squeak2.0/2.7segments/SqueakEasy.extSeg'.
"

	Project canWeLoadAProjectNow ifFalse: [^ self].
	ComplexProgressIndicator new 
		targetMorph: nil;
		historyCategory: 'project loading';
		withProgressDo: [
			ProgressNotification signal: '1:foundMostRecent'.
			fileName _ (urlString findTokens: '/') last.
			fileAndDir _ self bestAccessToFileName: fileName andDirectory: urlString.
			self
				openName: fileName 
				stream: fileAndDir first 
				fromDirectory: fileAndDir second
				withProjectView: nil.
		]

