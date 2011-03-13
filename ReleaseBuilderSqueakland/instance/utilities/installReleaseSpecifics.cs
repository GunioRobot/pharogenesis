installReleaseSpecifics
	"ReleaseBuilderSqueakland new installReleaseSpecifics"

	| serverName serverURL serverDir updateServer |

	ProjectLauncher splashMorph: (FileDirectory default readOnlyFileNamed: 'scripts\SqueaklandSplash.morph') fileInObjectAndCode.

	"Dump all morphs so we don't hold onto anything"
	World submorphsDo:[:m| m delete].

	World color: (Color r: 0.9 g: 0.9 b: 1.0).

	"Clear all server entries"
	ServerDirectory serverNames do: [:each | ServerDirectory removeServerNamed: each].
	SystemVersion current resetHighestUpdate.

	"Add the squeakalpha update stream"
	serverName := 'Squeakalpha'.
	serverURL := 'squeakalpha.org'.
	serverDir := serverURL , '/'.

	updateServer := ServerDirectory new.
	updateServer
		server: serverURL;
		directory: 'updates/';
		altUrl: serverDir;
		user: 'sqland';
		password: nil.
	Utilities updateUrlLists addFirst: {serverName. {serverDir. }.}.

	"Add the squeakland update stream"
	serverName := 'Squeakland'.
	serverURL := 'squeakland.org'.
	serverDir := serverURL , '/'.

	updateServer := ServerDirectory new.
	updateServer
		server: serverURL;
		directory: 'public_html/updates/';
		altUrl: serverDir.
	Utilities updateUrlLists addFirst: {serverName. {serverDir. }.}.

