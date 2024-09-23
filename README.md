# CrossPlatformLabs
Варіант 35

## Запуск
Щоб запустити лабораторну, виконати білд або запустити тести, користуйтеся наступними командами, які варто запускати з кореня репозиторію:

Запустити лабораторну:
```bash
dotnet build Build.proj -t:Run -p:Solution=Lab1
```

Білд:
```bash
dotnet build Build.proj -t:Build -p:Solution=Lab1
```

Тести:
```bash
dotnet build Build.proj -t:Test -p:Solution=Lab1
```

Де `Lab1` може бути замінена на `Lab2`, щоб запустити лабораторну №2, `Lab3` - лабораторна №3, тощо.

## Лабораторні
Для кожної лабораторної є окрема папка із solution:
- [Lab1](./Lab1/)
