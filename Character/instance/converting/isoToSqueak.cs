isoToSqueak 
	"Convert receiver from iso8895-1 (actually CP1252) to mac encoding.
	Does not do lf/cr conversion!

	To make the round-trip conversion possible, each undefined code point is mapped to a unique value.

	For each c in Character, c squeakToIso isoToSqueak = c, and c isoToSqueak squeakToIso = c is true.  Also, for each array literals in squeakToIso and isoToSqueak, self size = self asSet size is true.  Finally, the table is compabie with the 'keymap' table in the Windows VM.
"

	value < 128 ifTrue: [^ self].
	value > 255 ifTrue: [^ self].
	^ Character value: (#(
		173 176 226 196 227 201 160 224 246 228 178 220 206 179 182 183	"80-8F"
		184 212 213 210 211 165 208 209 247 170 185 221 207 186 189 217	"90-9F"
		202 193 162 163 219 180 195 164 172 169 187 199 194 197 168 248	"A0-AF"
		161 177 198 215 171 181 166 225 252 218 188 200 222 223 240 192 	"B0-BF"
		203 231 229 204 128 129 174 130 233 131 230 232 237 234 235 236 	"C0-CF"
		245 132 241 238 239 205 133 249 175 244 242 243 134 250 251 167	"D0-DF"
		136 135 137 139 138 140 190 141 143 142 144 145 147 146 148 149	"E0-EF"
		253 150 152 151 153 155 154 214 191 157 156 158 159 254 255 216	"F0-FF"
	) at: value - 127)
