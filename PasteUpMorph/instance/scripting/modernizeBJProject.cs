modernizeBJProject
	"Prepare a kids' project from the BJ fork of September 2000 -- a once-off thing for converting such projects forward to a modern 3.1a image, in July 2001.  Except for the #enableOnlyGlobalFlapsWithIDs: call, this could conceivably be called upon reloading *any* project, just for safety."

	"ActiveWorld modernizeBJProject"

	ScriptEditorMorph allInstancesDo:
		[:m | m userScriptObject].
	Flaps enableOnlyGlobalFlapsWithIDs: {'Supplies' translated}.
	ActiveWorld abandonOldReferenceScheme.
	ActiveWorld relaunchAllViewers.