score: move for: team
	"Return the decrease in distance toward this team's goal"

	| goal closerToGoal wasBack nowBack |
	goal _ homes atWrap: team+3.
	wasBack _ self distFrom: move first to: goal.
	nowBack _ self distFrom: move last to: goal.
	closerToGoal _ wasBack - nowBack.
	closerToGoal < -1 ifTrue: [^ -99].  "Quick rejection if move backward more than 1"
	(nowBack <= 3 and: [self checkDoneAfter: move]) ifTrue: [^ 999].
	"Reward closerToGoal, but add bias to move those left far behind."
	^ (closerToGoal*5) + wasBack