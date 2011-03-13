cmdKeyActivity
	"Check for relevant command keys.  If so, perform them and return true.  Subclasses should override for appropriate cmd keys.  See example code below."

"	| cmd |
	(cmd _ sensor ctrlChar) notNil
	ifTrue: [cmd _ cmd asLowercase.
			cmd = $x ifTrue: [view cmdX. ^ true].
			cmd = $c ifTrue: [view cmdC. ^ true].
			cmd = $v ifTrue: [view cmdV. ^ true].
			cmd = $d ifTrue: [view cmdD. ^ true]]."
	^ false