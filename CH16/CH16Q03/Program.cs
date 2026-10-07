using System;
using CH16Q03;

// 메모 초안 복제

// 원본 메모 내용, 원본 수정번호, 초안에 적용할 새 내용을 차레로 입력 // 내용은 빈문자열 가능
// Memo CopyMemo(Memo source) 함수로 원본과 같은 필드값을 가진 별도 객체를 반환
// 그 객체를 초안으로 사용하여 새 내용을 적용. 원본과 초안의 내용, 수정번호, 같은 객체 여부를 출력


// 원본 메모: 철수 발표
// 원본 수정 번호: 2
// 초안의 새 내용: 영희 발표

Memo original = new Memo();
Console.Write("원본 메모: ");
original.Text = Console.ReadLine();

Console.Write("원본 수정 번호: ");
original.Revision = int.Parse(Console.ReadLine());

Memo draft = CopyMemo(original);

Console.Write("초안의 새 내용: ");
string newText = Console.ReadLine();

Console.WriteLine($"원본: [{original.Text}] / {original.Revision}");

draft.Edit(newText);

Console.WriteLine($"초안: [{draft.Text}] / {draft.Revision}");
Console.WriteLine($"같은 객체: {original == draft}");

Memo CopyMemo(Memo source)
{
    Memo draft = new Memo();
    draft.Text = source.Text;
    draft.Revision = source.Revision;
    return draft;
}




