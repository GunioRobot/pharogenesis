stop
	"Stop any actions and animations associated with this object"

	| scheduler |

	scheduler _ myWonderland getScheduler.

	(scheduler getAnimationsFor: self) do: [:anim | anim stop ].

	(scheduler getActionsFor: self) do: [:action | action stop ].

	myChildren do: [:child | (child isPart) ifTrue: [ child stop ] ].