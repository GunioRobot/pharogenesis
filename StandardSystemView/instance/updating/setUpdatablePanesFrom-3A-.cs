setUpdatablePanesFrom: getSelectors
	| aList aPane |
	"Set my updatablePanes inst var to the list of panes which are list panes with the given get-list selectors.  Order is important here!  Note that the method is robust in the face of panes not found, but a warning is printed in the transcript in each such case"

	aList _ OrderedCollection new.
	getSelectors do:
		[:sel | aPane _ self subViewSatisfying:
				[:pane | (pane isKindOf: PluggableListView) and: [pane getListSelector == sel]].
			aPane
				ifNotNil:
					[aList add: aPane]
				ifNil:
					[Transcript cr; show: 'Warning: view ', sel, ' not found.']].
	updatablePanes _ aList asArray