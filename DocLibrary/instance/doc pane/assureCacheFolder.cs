assureCacheFolder
	"Make sure there is a folder docPaneCache and a file: url for it in DocsCachePath.  In local folder or one level up.  User may wish to install a different path and folder name (as a url).  Could be a url to a local server."

	| dir local |
	DocsCachePath ifNil: [
		dir _ FileDirectory default.
		(dir includesKey: 'docPaneCache') ifTrue: [
			DocsCachePath _ dir url, 'docPaneCache/']].
	DocsCachePath ifNil: [
		dir _ FileDirectory default containingDirectory.
		DocsCachePath _ dir url, 'docPaneCache/'.
		(dir includesKey: 'docPaneCache') ifFalse: [
			^ dir createDirectory: 'docPaneCache']].	"create the folder"
	local _ ServerDirectory new fullPath: DocsCachePath.
	local exists ifFalse: [
		DocsCachePath _ nil.	"we must be on a new disk"
		self assureCacheFolder].