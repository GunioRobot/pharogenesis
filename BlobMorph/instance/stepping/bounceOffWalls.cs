bounceOffWalls
	" Change sign of velocity when we hit a wall of the container "
	| ob sb |

	" If owned by a handmorph we're being dragged or something;
	  don't bounce since the boundaries are different than our real parent "
	owner isHandMorph ifTrue: [ ^ self ].

	" If we're entirely within the parents bounds, we don't bounce "
	ob := owner bounds.
	sb := self bounds.
	(ob containsRect: sb) ifTrue: [ ^ self ].

	" We're partly outside the parents bounds; better bounce or we disappear! "
	sb top < ob top ifTrue: [ velocity := velocity x @ velocity y abs ].
	sb left < ob left ifTrue: [ velocity := velocity x abs @ velocity y ].
	sb bottom > ob bottom ifTrue: [ velocity := velocity x @ velocity y abs negated ].
	sb right > ob right ifTrue: [ velocity := velocity x abs negated @ velocity y ].
