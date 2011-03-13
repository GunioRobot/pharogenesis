okToChange
	"Answer whether the window in which the project is housed can be dismissed -- which is destructive. We never clobber a project without confirmation"

	| ok is list |
	self subProjects size  >0 ifTrue:
		[PopUpMenu notify: 
'The project ', self name printString, '
contains sub-projects.  You must remove these
explicitly before removing their parent.'.
		^ false].
	ok _ world isMorph not and: [world scheduledControllers size <= 1].
	ok ifFalse: [self isMorphic ifTrue: [
		self parent == CurrentProject 
			ifFalse: [^true]]].  "view from elsewhere.  just delete it."
	ok _ (self confirm:
'Really delete the project
', self name printString, '
and all its windows?').
		
	ok ifFalse: [^ false].

	world isMorph 
		ifTrue: [world submorphs do:   "special release for wonderlands"
						[:m | (m isKindOf: WonderlandCameraMorph)
								and: [m getWonderland release]].
			"Remove Player classes and metaclasses owned by project"
			is _ ImageSegment new arrayOfRoots: (Array with: self).
			(list _ is rootsIncludingPlayers) ifNotNil: [
				list do: [:playerCls | 
					(playerCls respondsTo: #isMeta) ifTrue: [
						playerCls isMeta ifFalse: [
							playerCls removeFromSystemUnlogged]]]]].

	self removeChangeSetIfPossible.
	"do this last since it will render project inaccessible to #allProjects and their ilk"
	Project deletingProject: self.
	^ true
