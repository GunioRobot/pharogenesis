defaultStemUrl
	"For writing on an FTP directory.  Users should insert their own server url here."
"ftp://jumbo.rd.wdi.disney.com/raid1/people/dani/Books/Grp/Grp"
"	ServerDirectory defaultStemUrl	"

| rand dir |
rand _ String new: 4.
1 to: rand size do: [:ii |
	rand at: ii put: ('bdfghklmnpqrstvwz' at: 17 atRandom)].
dir _ self serverNamed: 'DaniOnJumbo'.
^ 'ftp://', dir server, dir slashDirectory, '/BK', rand