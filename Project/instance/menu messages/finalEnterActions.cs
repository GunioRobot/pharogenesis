finalEnterActions
	"Perform the final actions necessary as the receiver project is entered"

	| navigator armsLengthCmd navType thingsToUnhibernate fixBlock |

	self projectParameters 
		at: #projectsToBeDeleted 
		ifPresent: [ :projectsToBeDeleted |
			self removeParameter: #projectsToBeDeleted.
			projectsToBeDeleted do: [ :each | 
				Project deletingProject: each.
				each removeChangeSetIfPossible]].

	thingsToUnhibernate _ world valueOfProperty: #thingsToUnhibernate ifAbsent: [#()].
	(thingsToUnhibernate anySatisfy:[:each| 
		each isMorph and:[each hasProperty: #needsLayoutFixed]]) 
			ifTrue:[fixBlock := self displayFontProgress].
	thingsToUnhibernate do: [:each | each unhibernate].
	world removeProperty: #thingsToUnhibernate.

	fixBlock ifNotNil:[
		fixBlock value.
		world fullRepaintNeeded.
	].

	navType _ ProjectNavigationMorph preferredNavigator.
	armsLengthCmd _ self parameterAt: #armsLengthCmd ifAbsent: [nil].
	navigator _ world findA: navType.
	(Preferences classicNavigatorEnabled and: [Preferences showProjectNavigator and: [navigator isNil]]) ifTrue:
		[(navigator _ navType new)
			bottomLeft: world bottomLeft;
			openInWorld: world].
	navigator notNil & armsLengthCmd notNil ifTrue:
		[navigator color: Color lightBlue].
	armsLengthCmd notNil ifTrue:
		[Preferences showFlapsWhenPublishing
			ifFalse:
				[self flapsSuppressed: true.
				navigator ifNotNil:	[navigator visible: false]].
		armsLengthCmd openInWorld: world].
	Smalltalk isMorphic ifTrue:
		[world reformulateUpdatingMenus.
		world presenter positionStandardPlayer].

	WorldState addDeferredUIMessage: [self startResourceLoading].