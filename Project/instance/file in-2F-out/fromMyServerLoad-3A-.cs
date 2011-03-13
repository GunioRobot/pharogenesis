fromMyServerLoad: otherProjectName
	| servers pair pr dirToUse |
	"If a newer version of me is on the server, load it."

	(pr _ Project named: otherProjectName) ifNotNil: ["it appeared"
		^ pr enter
	].
	(servers _ self serverList) ifNil: [
		lastDirectory ifNil: [
			self inform: 'Current project does not know a server either.'.
			^nil
		].
		dirToUse _ lastDirectory.
	] ifNotNil: [
		dirToUse _ servers first.
	].
	pair _ self class mostRecent: otherProjectName onServer: dirToUse.
	pair first ifNil: [^self decideAboutCreatingBlank: otherProjectName].	"nothing to load"
	^ProjectLoading
		installRemoteNamed: pair first
		from: dirToUse
		named: otherProjectName
		in: self

