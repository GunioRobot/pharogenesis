pause
	"Pause any actions and animations associated with this object"

	| scheduler |

	scheduler _ myWonderland getScheduler.

	(scheduler getAnimationsFor: self) do: [:anim | anim pause ].

	(scheduler getActionsFor: self) do: [:action | action pause ].

	myChildren do: [:child | (child isPart) ifTrue: [ child pause ] ].