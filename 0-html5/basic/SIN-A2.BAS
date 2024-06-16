' This program exported from BASIC Anywhere Machine 
' (Version [5.2.3].[2023.12.16.16.28]) on 2024.05.21 at 02:21 (Coordinated Universal Time)
' This port and mod by Charlie Veniot
' of a program by Filho Junior
' Modified lines preceded by the commented out original lines
' New lines added without line number

100 DIM rr(0 TO 320) 
105 dim cc(0 TO 4)
' 110 SCREEN 8: COLOR 3, 0
110 SCREEN _NEWIMAGE(400,160,0): COLOR 3, 0

FOR i = 0 TO 4
cc(i) = INT(RND(15) * 14 + 1)
NEXT i

120 FOR i = 0 TO 320: rr(i) = 193: NEXT i
130 xp = 144: xr = 4.7123: xf = xr / xp
140 FOR zi = 64 TO -64 STEP -1
150 zt = zi * 2.25: zs = zt * zt
'160 xl = INT(SQR(20736 - zs) + .5): COLOR INT(RND(15) * 15)
160 xl = INT(SQR(20736 - zs) + .5): COLOR cc(INT(RND*5))
170 xx = zi + 160: zy = 90 + zi
180 FOR xi = 0 TO xl
190 xt = SQR(xi * xi + zs) * xf
200 yy = (SIN(xt) + SIN(xt * 3) * .4) * 56
210 x1 = INT(xi + zx): y1 = INT(zy + yy)
220 IF rr(x1) > y1 THEN rr(x1) = y1: PSET (x1 + 200, y1 + 30)
230 x1 = zx - xi
240 IF rr(x1 + 300) > y1 THEN rr(x1 + 300) = y1: PSET (x1 + 200, y1 + 30)
250 NEXT xi: NEXT zi
