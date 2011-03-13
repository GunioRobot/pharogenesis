prepareForExternalReleaseNamed: aReleaseName
	"ScriptingSystem prepareForExternalReleaseNamed: '2.2Beta'"

	EToySystem stripMethodsForExternalRelease.

	ScriptingSystem saveFormsToFileNamed: aReleaseName, '.Dis.Forms'.
	ScriptingSystem stripGraphicsForExternalRelease.
	ScriptingSystem cleanupsForRelease.
	ScreenController initialize.
