additionsToViewerCategoryPreferences
	"Answer a list of (<categoryName> <list of category specs>) pairs that characterize the phrases this kind of morph wishes to add to various Viewer categories."

	^ #(preferences (
			(slot useVectorVocabulary 'Whether to use the Vector vocabulary with etoy scripting in this project' Boolean readWrite Player getUseVectorVocabulary Player setUseVectorVocabulary:)
			(slot dropProducesWatcher 'Whether a drop of a value tile, such as "car''s x", on the desktop, should produce a watcher for that value' Boolean readWrite Player getDropProducesWatcher Player setDropProducesWatcher:)
			(slot allowEtoyUserCustomEvents 'Whether to allow "custom events" in etoys.' Boolean readWrite Player getAllowEtoyUserCustomEvents Player setAllowEtoyUserCustomEvents:)
			(slot batchPenTrails 'Whether pen trails should reflect small movements within the same tick or only should integrate all movement between ticks' Boolean readWrite Player getBatchPenTrails Player setBatchPenTrails:)
			"(slot eToyFriendly 'Whether various restrictions should apply in many parts of the system.  Intended to be set to true for younger users.' Boolean readWrite Player getEToyFriendly Player setEToyFriendly:)"
			(slot fenceEnabled 'Whether an object hitting the edge of the screen should be kept "fenced in", rather than being allowed to escape and disappear' Boolean readWrite Player getFenceEnabled Player setFenceEnabled:)
			(slot keepTickingWhilePainting 'Whether scripts should continue to run while you''re using the painting system' Boolean readWrite Player getKeepTickingWhilePainting Player setKeepTickingWhilePainting:)
			(slot oliveHandleForScriptedObjects 'Whether the default green halo handle (at the top right of the halo) should, for scripted objects, be the olive-green handle, signifying that use will result in a sibling instance. ' Boolean readWrite Player getOliveHandleForScriptedObjects  Player setOliveHandleForScriptedObjects: )
	))