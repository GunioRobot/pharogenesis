cutSelection: selection

	| track selStartTime delta |
	track _ tracks at: selection first.
	selStartTime _ (track at: selection second) time.
	track _ track copyReplaceFrom: selection second to: selection third with: Array new.
	track size >=  selection second ifTrue:
		["Adjust times of following events"
		delta _ selStartTime - (track at: selection second) time.
		selection second to: track size do:
			[:i | (track at: i) adjustTimeBy: delta]].
	tracks at: selection first put: track