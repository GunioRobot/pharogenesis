installReleaseSpecifics
	"Currently just clear and add the ServerDirectories
	and update streams we want as default."

	"Clear all server entries"
	ServerDirectory serverNames do: [:each | ServerDirectory removeServerNamed: each].

	"Add default entries, added an entry for the new file area.
	The others are the current ones that see to work 
	as of 2005-02-28 and I recreated them using source."
	ServerDirectory addServer: (ServerDirectory new 
		type: #ftp;
		user: '';
		server: 'box1.squeakfoundation.org';
		altUrl: 'http://box1.squeakfoundation.org/files';
		directory: 'files';
		keepAlive: false) named: 'Squeak.org Archive'.
	ServerDirectory addServer: (ServerDirectory new 
		type: #ftp;
		server: 'st.cs.uiuc.edu';
		user: 'anonymous';
		directory: '/Smalltalk/Squeak';
		keepAlive: false) named: 'UIUC Archive'.	
	ServerDirectory addServer: (ServerDirectory new 
		type: #ftp;
		server: 'ftp.create.ucsb.edu';
		user: 'anonymous';
		directory: '/pub/Smalltalk/Squeak';
		keepAlive: false) named: 'UCSBCreate Archive'.
	ServerDirectory addServer: SuperSwikiServer defaultSuperSwiki named: 'Bob SuperSwiki'.
	ServerDirectory addServer: (SuperSwikiServer new 
		type: #http;
		server: 'squeakland.org:8080';
		altUrl: 'http://www.squeakland.org/uploads';
		directory: '/super/SuperSwikiProj';
		keepAlive: false;
		acceptsUploads: true) named: 'Squeakland SuperSwiki'.
	ServerDirectory addServer: (HTTPServerDirectory new 
		type: #ftp;
		user: 'sqland';
		server: 'www.squeakland.org';
		altUrl: 'http://www.squeakland.org/projects';
		directory: 'projects';
		keepAlive: false) named: 'Squeakland Projects'.

"Add the update streams here just as Squeakland does?
	serverName _ 'Squeakland'.
	serverURL _ 'squeakland.org'.
	serverDir _ serverURL , '/'.
	updateServer _ ServerDirectory new.
	updateServer
		server: serverURL;
		directory: 'public_html/updates/';
		altUrl: serverDir.
	Utilities updateUrlLists addFirst: {serverName. {serverDir. }.}.
"
