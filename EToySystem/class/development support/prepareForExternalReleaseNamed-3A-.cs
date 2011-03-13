prepareForExternalReleaseNamed: aReleaseName
	"EToySystem prepareForExternalReleaseNamed: '2.0Beta'"

	self stripMethodsForExternalRelease.

	EToySystem class compile: 'guessDOLProxy
	"deleted for external release"' classified: 'stripped'.

	ScriptingSystem saveFormsToFileNamed: aReleaseName, '.Dis.Forms'.
	EToySystem stripGraphicsForExternalRelease.
	EToySystem cleanupsForRelease.
	ScreenController initialize.
