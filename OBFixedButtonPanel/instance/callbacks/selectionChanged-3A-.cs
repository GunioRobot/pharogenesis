selectionChanged: ann
	| node nodeActions |
	node _ browser currentNode ifNil: [^ self].
	nodeActions _ (node metaNode actionsForNode: node) select: [:ea | ea wantsButton].
	actions keys do: 
		[:model | 
		actions at: model put: nil.
		nodeActions do: 
			[:action | model label = action buttonLabel ifTrue: [actions at: model put: action]]].
	actions keys do: [:ea | ea selectionChanged].