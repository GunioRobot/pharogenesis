fromUrl: urlString
	"Load the project, and make a thumbnail to it in the current project.  Replace the old one if necessary.
Project fromUrl: 'http://www.squeak.org/Squeak2.0/2.7segments/Squeak_Easy.pr.gz'.
"

	| pair projName proj triple serverDir projectFilename serverUrl absoluteUrl |
	Project canWeLoadAProjectNow ifFalse: [^ self].

	"serverFile _ HTTPLoader default contentStreamFor: urlString."
	absoluteUrl := (Url schemeNameForString: urlString)
		ifNil: [urlString asUrlRelativeTo: FileDirectory default url asUrl]
		ifNotNil: [Url absoluteFromText: urlString].
	projectFilename _ absoluteUrl path last.
	triple _ Project parseProjectFileName: projectFilename unescapePercents.
	projName _ triple first.
	(proj _ Project named: projName)
		ifNotNil: ["it appeared" ^ ProjectEntryNotification signal: proj].

	serverUrl _ (absoluteUrl copy path: (absoluteUrl path copyWithout: absoluteUrl path last)) toText.
	serverDir _ ServerDirectory serverForURL: serverUrl.
	serverDir
		ifNil: ["we just have a url, no dedicated project server"
			ProjectLoading
				installRemoteNamed: projectFilename
				from: absoluteUrl toText unescapePercents
				named: projName
				in: CurrentProject.].
	pair _ self mostRecent: projectFilename onServer: serverDir.
	"Pair first is name exactly as it is on the server"
	pair first ifNil: [^self openBlankProjectNamed: projName].

	ProjectLoading
		installRemoteNamed: pair first
		from: serverDir
		named: projName
		in: CurrentProject.