initialize
	"B3DTutorialPresenter initialize"
	 (TheWorldMenu respondsTo: #registerOpenCommand:)
         ifTrue: [TheWorldMenu registerOpenCommand: {'Balloon3D Tutorial'. {self. #openTutorial}}].
