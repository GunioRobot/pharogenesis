resume
	"Resume any actions and animations associated with this object"

	| scheduler |

	scheduler _ myWonderland getScheduler.

	(scheduler getAnimationsFor: self) do: [:anim | anim resume ].

	(scheduler getActionsFor: self) do: [:action | action resume ].

	myChildren do: [:child | (child isPart) ifTrue: [ child resume ] ].