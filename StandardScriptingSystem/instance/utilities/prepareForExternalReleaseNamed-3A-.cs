prepareForExternalReleaseNamed: aReleaseName
	"ScriptingSystem prepareForExternalReleaseNamed: '2.2Beta'"

	EToySystem stripMethodsForExternalRelease.

	self class compile: 'guessDOLProxy
	"deleted for external release"' classified: 'stripped'.

	ScriptingSystem saveFormsToFileNamed: aReleaseName, '.Dis.Forms'.
	ScriptingSystem stripGraphicsForExternalRelease.
	ScriptingSystem cleanupsForRelease.
	ScreenController initialize.
