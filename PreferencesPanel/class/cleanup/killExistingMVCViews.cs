killExistingMVCViews
	"Kill all existing preferences views in mvc"
"
PreferencesPanel killExistingMVCViews
"
	| byebye |

	ControlManager allInstances do: [ :cm |
		byebye _ cm controllersSatisfying: [ :eachC |
			self isAPreferenceViewToKill: eachC view].
		byebye do: [ :each | 
			each status: #closed.
			each view release.
			cm unschedule: each]]