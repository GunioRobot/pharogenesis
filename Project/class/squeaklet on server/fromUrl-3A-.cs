fromUrl: urlString
	| serverFile pair projName proj num triple serverDir |
	"Load the project, and make a thumbnail to it in the current project.  Replace the old one if necessary.
Project fromUrl: 'http://www.squeak.org/Squeak2.0/2.7segments/Squeak_Easy.pr.gz'.
"

	Project canWeLoadAProjectNow ifFalse: [^ self].
	serverFile _ Project serverFileFromURL: urlString.
	serverDir _ serverFile directoryObject.
	triple _ Project parseProjectFileName: serverFile fileName unescapePercents.
	projName _ triple first.
	(proj _ Project named: projName) ifNotNil: ["it appeared" ^ ProjectEntryNotification signal: proj].
	serverDir isTypeHTTP
		ifTrue: [num _ triple second.
			pair _ Array with: serverFile fileName with: num]
		ifFalse: [pair _ self mostRecent: serverFile localName onServer: serverDir].
	"Pair first is name exactly as it is on the server"
	pair first ifNil: [^self openBlankProjectNamed: projName].

	ProjectLoading
		installRemoteNamed: pair first
		from: serverDir
		named: projName
		in: CurrentProject.